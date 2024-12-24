#import "@preview/codly:1.0.0": *
#import "@preview/tablex:0.0.9": tablex, rowspanx, colspanx

#let name = "王俊亚"
#let stuNum = "22307049"

#let template(title, doc) = {
  show ref: it => {
    set text(fill: orange)
    it
  }
  set page(
    paper: "us-letter",
    header: align(right)[
      #set text(font: "Monotype Corsiva")
      Database Principle
    ],
    numbering: "1/1",
  )

  show: codly-init.with()

  codly(
    languages: (
      CSharp: (
        name: "C#",
        icon: text(font: "tabler-icons", "\u{fa53}"),
        color: rgb("#CE412B")
      ),
      cs: (
        name: "C#",
        icon: text(font: "tabler-icons", "\u{fa53}"),
        color: rgb("#CE412B")
      ),
      SQL: (
        name: "SQL",
        icon: text(font: "tabler-icons", "\u{fa63}"),
        color: rgb("#46ce2b")
      ),
      sql: (
        name: "SQL",
        icon: text(font: "tabler-icons", "\u{fa63}"),
        color: rgb("#46ce2b")
      ),
    )
  )

  set par(justify: true)
  set document(author: name, title: title, date: auto)
  set text(font: "STSong", lang: "zh", region: "cn")
  show heading: set block(above: 2em, below: 1em)
  set heading(numbering: "I.1.A.a")
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
    #tablex(
      columns: 3,
      align: center + horizon,
      auto-vlines: false,
      header-rows: 2,

      [姓名], [], [学号],
      [王俊亚], [], [22307049],
      [王炳睿], [], [22354124]
    )
  ]

  show outline: set text(fill: rgb("#006d12"))
  outline(indent: 2.5em)
  pagebreak()

  set ref(supplement: it => {
    if (it.func() == heading) {
      "章节"
    }
    else if (it.func() == figure) {
      "图"
    }
    else {
      "Thing"
    }
  })

  show ref: it => {
    if (it.element == none) {
      it
    }
    else if (it.element.func() == heading) {
      it
      let l = it.target // label
      let h = it.element // heading
      link(l, [ [ #h.body ]])
    }
    else if (it.element.func() == figure) {
      it
      let l = it.target // label
      let h = it.element // heading
      link(l, [ [ #h.caption.body ]])
    }
    else {
      it
    }
  }

  doc
}