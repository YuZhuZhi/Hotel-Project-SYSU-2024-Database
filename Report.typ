#import "@preview/fletcher:0.5.2" as fletcher: diagram, node, edge
#import "@preview/tablex:0.0.9": tablex, rowspanx, colspanx
#import "@preview/cetz:0.3.0"
#import "template.typ": template

#show: doc => template(
  [数据库期末项目],
  doc
)

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 引言

== 设计目的

我们将要设计实现的，是一个拥有友好用户界面的、简单易用的、面向酒店管理人员(而不是入住者)的酒店预订管理系统。我们将要实现以下模块：

+ 酒店信息管理负责酒店信息的添加、修改和查询；
+ 房间信息管理负责房间信息的添加、修改和查询；
+ 预订信息管理负责预订信息的录入、修改和查询。

== 设计环境

我们首先考虑后端语言的选择。我们希望能够便捷地、现代化地使用程序语言操作数据库，这里便排除掉了繁琐且内存不安全的C与C++语言，而在JAVA, Python, C\#中选择。考虑到大部分的使用环境都是Windows，且并非所有人都会在计算机中安装JVM，因此我们又排除掉了JAVA；但同时考虑小部分情况下的跨平台性，且Python不易打包成可执行文件，我们最终选择了C\#作为后端语言。

选择C\#作为后端语言后，我们惊喜地发现它也能同时胜任前端的构建。对于C\#，WinForm与WPF都是非常成熟的前端框架，其中尤以WinForm最具有简易性——它可以使用拖拽的方式构建前端界面！

因此我们最终敲定以C\#语言作为整个项目的基石，无需分别为了后端与前端专门学习两种语言。项目的环境最终如下所示：

- 数据库：PostgreSQL
- 后端语言：C\# @CSharpdocument
  - 使用官方的Npgsql作为连接与操控PostgreSQL数据库的驱动程序。
  - #link("https://www.npgsql.org/doc/index.html")[#text(blue, "Npgsql官方教程")] @npgsqldocument
- 前端语言：C\# @CSharpdocument
  - 使用WinForm作为开发前端的平台，而不是更加复杂的WPF。
  - 出于美观考量，使用开源的AntdUI作为界面库。
  - #link("https://gitee.com/antdui/AntdUI")[#text(blue, "AntdUI Gitee发布页")] @AntdUIdocument

== 人员分工

- 王俊亚：组长。

- 王炳睿：组员。

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 设计概要

== 系统需求分析

1. 酒店信息管理

酒店具有的具体信息有：酒店名称，酒店地址，酒店星级，房间类型及其总数。

2. 房间信息管理

酒店房间的具体信息有：酒店地址，房间编号，房间类型，单天价格，是否已被预订。

3. 预订信息管理

预订订单的具体信息有：订单编号，酒店地址，预订房间号，预订人身份证号，起始日期，旅居天数。

结合上述的具体信息，我们显然可以发现系统中具有实体集：酒店(Hotel)、房间(Room)、预订人(Reserver)。事实上，我们还应当从中分离出一个“房间类型(RoomType)”的实体集出来。其中的联系集是：(Hotel, RoomType)，酒店持有其独特的房间类型；(Room, RoomType)，房间自然是具有房间类型的；(Reserver, Room)，预订人会预订特定的房间。整理后我们可以绘制E-R图如下：

#let HotelTable() = {
  set text(font: "Cambria", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Hotel*], [#underline(stroke: (dash: "dashed"),offset: 3pt, extent: 0pt)[name]\ star]
)}

#let RoomTypeTable() = {
  set text(font: "Cambria", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*RoomType*], [#underline(offset: 3pt, extent: 2pt)[type]\ price\ amount]
)}

#let RoomTable() = {
  set text(font: "Cambria", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Room*], [#underline(stroke: (dash: "dashed"),offset: 3pt, extent: 0pt)[roomNO]\ isReserved]
)}

#let ReserverTable() = {
  set text(font: "Cambria", lang: "en")
  tablex(
    columns: 1,
    align: center + horizon,
    auto-vlines: true,
    header-rows: 1,

    [*Reserver*], [#underline(offset: 3pt, extent: 2pt)[ID]\ date\ duration]
)}

#let Address() = {
  set text(font: "Cambria", lang: "en")
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
  set text(font: "Cambria", lang: "en")
  cetz.canvas({
    import cetz.draw: *
    line((0,0), (30deg, 2), (0deg, 3.464), (-30deg, 2), (0,0), name: "line")
    set-style(content: (padding: 0.8))
    content("line.start", "Reservation", anchor: "west")
  })
}

#import fletcher.shapes: pill, parallelogram, diamond, hexagon

#figure(kind: table,
  caption: [
    酒店预订管理系统的E-R图
  ])[
    #align(center)[
    #set text(font: "Cambria", lang: "en")
    #diagram(
    spacing: 2cm, 
    node-stroke: black,{
    let (HT, Addr) = ((-1,0), (0,0))
    let (RT, RTT) = ((1,0), (0,-1))
    let (RST, Rsv) = ((0,1), (1,1))

    node(HT, HotelTable(), shape: rect)
    node(RT, RoomTable(), shape: rect)
    node(RTT, RoomTypeTable(), shape: rect)
    node(RST, ReserverTable(), shape: rect)
    node(Addr, [Address], shape: diamond, extrude: (-3, 0), inset: 10pt)
    node(Rsv, [Reservation], shape: diamond, inset: 10pt)

    edge(HT, Addr, "=")
    edge(RTT, Addr, "-")
    edge(RT, Addr, "=")
    edge(RT, Rsv, "<-")
    edge(RST, Rsv, "<-")
    edge(RST, Addr, "-")
})]]

== 系统结构设计



== 功能模块设计

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

= 详细设计

== 系统数据库设计

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


