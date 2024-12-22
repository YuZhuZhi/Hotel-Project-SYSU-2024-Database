#import "@preview/fletcher:0.5.2" as fletcher: diagram, node, edge
#import "@preview/tablex:0.0.9": tablex, rowspanx, colspanx
#import "@preview/cetz:0.3.0"
#import "@preview/lovelace:0.3.0": *
#import "template.typ": template

#show: doc => template(
  [数据库期末项目],
  doc
)

#show ref: it => {
  set text(fill: orange)
  it
}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 引言

== 背景故事

你将扮演一位坐拥几座酒店的管理者，在电脑桌前邂逅性格各异、能力独特的旅客们，和他们一起创造财富——同时，逐步发掘数据库的真相！

你的账户是DataBase，密码是password。当你正确输入上述信息时，输入框会变为绿色。

== 设计目的

我们将要设计实现的，是一个拥有友好用户界面的、简单易用的、面向酒店管理人员(而不是入住者)的酒店预订管理系统。我们将要实现以下模块：

+ 酒店信息管理负责酒店信息的添加、修改和查询；
+ 房间信息管理负责房间信息的添加、修改和查询；
+ 预订信息管理负责预订信息的录入、修改和查询。

== 设计环境

我们首先考虑后端语言的选择。我们希望能够便捷地、现代化地使用程序语言操作数据库，这里便排除掉了繁琐且内存不安全的C与C++语言，而在JAVA, Python, C\#中选择。考虑到大部分的使用环境都是Windows，且并非所有人都会在计算机中安装JVM，因此我们又排除掉了JAVA；但同时考虑小部分情况下的跨平台性，且Python不易打包成可执行文件，我们最终选择了C\#作为后端语言。

另一个有趣的点是，C\#具有独特的Linq查询表达式，与数据库语言颇为相似。这就允许我们在本地内存中进行相似的操作。

选择C\#作为后端语言后，我们惊喜地发现它也能同时胜任前端的构建。对于C\#，WinForm与WPF都是非常成熟的前端框架，其中尤以WinForm最具有简易性——它可以使用拖拽的方式构建前端界面！

因此我们最终敲定以C\#语言作为整个项目的基石，无需分别为了后端与前端专门学习两种语言，更是省去了两个不同语言间的调用过程。项目的环境最终如下所示：

- 数据库：PostgreSQL
- 后端语言：C\# @CSharpdocument
  - 使用官方的Npgsql作为连接与操控PostgreSQL数据库的驱动程序。
  - #link("https://www.npgsql.org/doc/index.html")[#text(blue, "Npgsql官方教程")] @npgsqldocument
- 前端语言：C\# @CSharpdocument
  - 使用WinForm作为开发前端的平台，而不是更加复杂的WPF。
  - 出于美观考量，使用开源的AntdUI作为界面库。
  - #link("https://gitee.com/antdui/AntdUI")[#text(blue, "AntdUI Gitee发布页")] @AntdUIdocument
  - 同时，AntdUI并没有提供表格相关组件，因此我们还使用了???。

== 人员分工

- 王俊亚：组长。负责统筹协调，后端代码编写，前端代码编写，前端界面美化与审查，报告书编写。

- 王炳睿：组员。负责前后端的逻辑连接。

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 设计概要

== 系统需求分析

1. 酒店信息管理

酒店具有的具体信息有：酒店名称，酒店地址，酒店星级，房间类型及其总数。

2. 房间信息管理

酒店房间的具体信息有：酒店地址，房间编号，房间类型，单天价格，是否已被预订。

3. 预订信息管理

预订订单的具体信息有：订单编号，酒店地址，预订房间号，预订人身份证号，起始日期，旅居天数。

结合上述的具体信息，我们显然可以发现系统中具有实体集：酒店(Hotel)、房间(Room)、预订人(Reserver)。事实上，我们还应当从中分离出一个“房间类型(RoomType)”的实体集出来。

其中的联系集是：(Hotel, RoomType)，酒店持有其独特的房间类型；(Room, RoomType)，房间自然是具有房间类型的；(Reserver, Room)，预订人会预订特定的房间；(Reserver, Hotel)，由于房间归属于酒店，因此还需要附加酒店信息。整理后我们可以绘制E-R图如@E-R 所示。

#let HotelTable() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Hotel*], [#underline(offset: 3pt, extent: 0pt)[hotelNO]\ name\ star]
)}

#let RoomTypeTable() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*RoomType*], [#underline(stroke: (dash: "dashed"),offset: 3pt, extent: 2pt)[type]\ price\ amount]
)}

#let RoomTable() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Room*], [#underline(stroke: (dash: "dashed"),offset: 3pt, extent: 0pt)[roomNO]\ isReserved]
)}

#let ReserverTable() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Reserver*], [#underline(offset: 3pt, extent: 2pt)[ID]\ date\ duration]
)}

#let Address() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  cetz.canvas({
    import cetz.draw: *
    line((0,0), (30deg, 2), (0deg, 3.464), (-30deg, 2), (0,0), name: "line")
    line((0.2,0), (1.732, 0.885))
    line((3.264,0), (1.732, 0.885))
    line((0.2,0), (1.732, -0.885))
    line((3.264,0), (1.732, -0.885))
    set-style(content: (padding: 1.1))
    content("line.start", "Address", anchor: "west")
  })
}

#let Reservation() = {
  set text(font: "SDK_SC_Unity", lang: "en")
  cetz.canvas({
    import cetz.draw: *
    line((0,0), (30deg, 2), (0deg, 3.464), (-30deg, 2), (0,0), name: "line")
    set-style(content: (padding: 0.8))
    content("line.start", "Reservation", anchor: "west")
  })
}

#import fletcher.shapes: pill, parallelogram, diamond, hexagon

#figure(kind: image,
  caption: [
    酒店预订管理系统的E-R图
  ], placement: auto)[
    #align(center)[
    #set text(font: "SDK_SC_Unity", lang: "en")
    #diagram(
    spacing: 2cm, 
    node-stroke: black,{
    let (HT, Addr) = ((-1,0), (0,-0.3))
    let (RT, RTT) = ((1,0), (0,-1))
    let (RST, Rsv) = ((0,1), (0,0.3))

    node(HT, HotelTable(), shape: rect)
    node(RT, RoomTable(), shape: rect)
    node(RTT, RoomTypeTable(), shape: rect)
    node(RST, ReserverTable(), shape: rect)
    node(Addr, [Address], shape: diamond, extrude: (-3, 0), inset: 10pt)
    node(Rsv, [Reservation], shape: diamond, inset: 10pt)
    // node((1, -1), [Type], shape: diamond, inset: 10pt)
    node((1,1), [orderNO], shape: rect)

    edge(HT, Addr, "-")
    edge(RTT, Addr, "=")
    edge(RT, Addr, "=")
    edge(RT, Rsv, "-")
    edge(RST, Rsv, "-")
    edge(HT, Rsv, "-")
    edge(Rsv, (1,1), "--")
    // edge(RTT, (1,-1), "<-")
    // edge(RT, (1,-1))
})]] <E-R>

方便起见，在之后的设计中，我们以酒店编号(hotelNO)来代替地址(Address)。在数据库中，相关属性会以hotelNO的名字出现；在用户界面中，尽管列名会显示为“酒店地址”，但其中的内容依然会以不同的数字形式出现。

== 系统结构设计

我们设计的系统中，通用的流程是：在未创建表的情况下，首先创建表格并初始化。同时，在本地内存与数据库中都持有表格。之后的一切操作，先在本地通过算法初步判断是否是合法的更新；如果合法，那么就更新本地表格；之后，再更新数据库中的数据。如果数据库更新成功，后端才返回更新成功的指示。

从结构上来说，我们自底向上设计。我们首先实现C\# 语言对Postgre数据库的相关操作；之后在此基础上，实现对酒店预订信息的管理；最后基于上述实现，设计美观优雅易操作的用户界面。这将会在下一节 @FunctionModuleDesign < 功能模块设计 >中体现。

== 功能模块设计 <FunctionModuleDesign>

#let Level() = {
  set text(font: "SDK_SC_Unity", size: 0.9em)
  pseudocode-list(line-numbering: none, booktabs: true, hooks: 1em, indentation: 1.5em)[
  + Main
  + DataBase 
    + Postgre
    + GenerateCommand
  + HotelManage
    + TableBase
      + Hotel
      + RoomType
      + Room
      + Reserver
      + Address
      + Reservation
    + Manager
  + UI
    + MainForm
    + ManageForm
      + TODO
  ]
}

#grid(
  columns: 2,
  gutter: 2em,
  [在这个项目中，我们设计的功能模块层级结构如右图所示。由于C\#语言的语言特性，图中列出的层级结构不一定代表真实文件结构，仅具有逻辑含义。同时，所列项目也不一定是文件名或类名，具体含义请看左边的具体释义。

  - Main是整个项目的入口，即主函数
  - DataBase命名空间，用于较底层与数据库沟通的功能
    - Postgre类，即对Npgsql中基础功能的封装
    - GenerateCommand类，用于较为系统地生成SQL语句
  - HotelManage命名空间用于管理酒店数据库相关表格
    - TableBase类，是六张表格的基类
      - Hotel, RoomType...等六张内存中的表格
    - Manager类，管理上述六张表格
  - UI命名空间，实现项目的前端界面],
  
  figure(
  diagram(node-stroke: black, {
    node((0, 0), Level(), shape: rect)
  }),
  
  caption: [功能模块设计层级结构],
  placement: bottom
  ), 
)

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 详细设计

== 系统数据库设计

根据E-R图，六张表对应的创建表格指令分别是：

1. 酒店表：

```SQL
CREATE TABLE Hotel (
  hotelNO  int      NOT NULL PRIMARY KEY,
  name     char(10) NOT NULL,
  star     int      NOT NULL);
```

2. 房间类型表：

```SQL
CREATE TABLE RoomType(
  hotelNO  int       NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE,
  type     char(10)  NOT NULL,
  price    int       NOT NULL,
  amount   int       NOT NULL,
  PRIMARY KEY (hotelNO, type));
```

3. 房间表：

```SQL
CREATE TABLE Room(
  hotelNO    int     NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE,
  roomNO     int     NOT NULL,
  isReserved boolean NOT NULL,
  PRIMARY KEY (hotelNO, roomNO));
```

4. 预订人表：

```SQL
CREATE TABLE Reserver (
  hotelNO  int      NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE,
  ID       int      NOT NULL PRIMARY KEY,
  date     date     NOT NULL,
  duration interval NOT NULL);
```

5. 地址表：

```SQL
CREATE TABLE Address (
  hotelNO  int      NOT NULL,
  roomNO   int      NOT NULL,
  type     CHAR(10) NOT NULL,
  PRIMARY KEY (hotelNO, roomNO),
  FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO) ON DELETE CASCADE,
  FOREIGN KEY (hotelNO, type) REFERENCES RoomType(hotelNO, type) ON DELETE CASCADE);
```

1. 预订表：

```SQL
CREATE TABLE Reservation (
  orderNO  serial NOT NULL PRIMARY KEY,
  ID       int    NOT NULL REFERENCES Reserver(ID) ON DELETE CASCADE,
  hotelNO  int    NOT NULL,
  roomNO   int    NOT NULL,
  FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO) ON DELETE CASCADE);
```

在每一张表中，所有属性都完全依赖于主键或主键元组，因此这些表至少是符合2-NF范式的；同时，也不存在传递依赖，因此系统数据库是符合3-NF范式的。

== 主要功能模块



== 各模块算法



//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 调试与问题

== 问题

== 解决方案

== 解决效果

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 总结

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

#set text(font: "Times New Roman", lang: "en", region: "en")

#show bibliography: set heading(numbering: "I")

#bibliography("reference.bib", style: "ieee", title: "参考文献")


