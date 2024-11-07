#let name = "王俊亚"
#let stuNum = "22307049"

#let template(title, doc) = {
  set page(
    paper: "us-letter",
    header: align(right)[
      #set text(font: "Monotype Corsiva")
      Database Principle
    ],
    numbering: "1/1",
  )
  set par(justify: true)
  set document(author: name, title: title, date: auto)
  set text(font: "STSong", lang: "zh", region: "cn")
  show heading: set block(above: 2em, below: 1em)
  set heading(numbering: "I.1.1")
  show heading: it => block[
    #set text(font: "STZhongsong")
    #counter(heading).display()
    #strong(it.body)
  ]

  align(center)[
    #set text(30pt, font: "")
    数据库原理

    #set text(20pt)
    #title

    #set text(15pt)
    姓名：#name \
    学号：#stuNum
  ]

  outline(indent: 2.5em)
  pagebreak()

  doc
}