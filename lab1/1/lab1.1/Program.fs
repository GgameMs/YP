open System

//1.1 Сформировать список из чисел, противоположный вводимым значениям

let input =
    printfn "Введите, сколько чисел вы хотите ввести"
    int(Console.ReadLine())

let list n =
    [
        for i in 1..n do
            printfn "Введите число"
            let x = int(Console.ReadLine())
            yield -x
    ]

[<EntryPoint>]
let main _ = 
    let n = input
    if n < 0
    then printf "Список невозможно создать"
    else printfn "Список противоположных элементов: %A" (list n)
    0
