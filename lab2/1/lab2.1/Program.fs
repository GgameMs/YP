open System

//2.1 Получить список из максимальных цифр натуральных чисел, содержащихся в исходном списке

let rec input ()=
    printfn "Создание списка\nВведите кол-во эл. списка"
    let n = int(Console.ReadLine())
    if n >= 0
    then
        [
        for i in 1..n do
            printfn "Введите эл. списка"
            yield int(Console.ReadLine())
        ]
    else
        printfn "Невозможно создать список"
        input ()
    
let rec search n m =
    if n < 10
    then
        if n%10 > m
        then
            n
        else
            m
    else
        if n%10 > m
        then
            search (n/10) (n%10)
        else
            search (n/10) (m)

let max_figure l1 = List.map (fun x -> search x 0) l1


[<EntryPoint>]
let main _ =
    let n = input ()
    printfn "Список максимальных цифр: %A?" (max_figure n)
    0