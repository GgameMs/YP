open System

//1.3 Собственные функции операций над списками

let input ()=
    printfn "Введите кол-во эл. списка"
    let n = int(Console.ReadLine())
    [
    for i in 1..n do
        printfn "Введите эл. списка"
        yield int(Console.ReadLine())
    ]

let ListOps () =
    printfn "Выберите операцию:\n1: удаление элемента по индексу\n2: сцепка двух списков\n3: получение элемента по индексу"
    int(Console.ReadLine())
    
let L_merge l1 l2 = l1 @ l2

let del_el_index l1 i=
    let left = l1 |> List.take i
    let right = l1 |> List.skip (i+1)
    L_merge left right
    
let el_from_ordinal l1 n = 1

let rec input_index () =
    printfn "Введите индекс нужного числа"
    let n = int(Console.ReadLine())
    if n < 0
    then
        printfn "Это не индекс" 
        input_index ()
    else n

let srch_index (l1: 'a list) i = l1.Item(i)


[<EntryPoint>]
let main _ =
    let n = ListOps ()
    if n = 1
    then
        printfn "Создание списка"
        let List1 = input ()
        let i = input_index ()
        if i >= 0
        then
            let List2 = del_el_index List1 i
            printfn "Новый список, без элемента под индексом %i: %A" i List2
    if n = 2
    then
        printfn "Создание списка 1"
        let List1 = input ()
        printfn "Создание списка 2"
        let List2 = input ()
        let List3 = L_merge List1 List2
        printfn "Новый список, сцепленный из %A и %A = %A" List1 List2 List3
    if n = 3
    then
        printfn "Создание списка"
        let List1 = input ()
        let i = input_index ()
        if i >= 0
        then
            let NUM = srch_index List1 i
            printfn "Элемент, под индексом %i: %i" i NUM
    0
