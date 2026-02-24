open System

//1.2 Найти количество цифр натурального числа

let input =
    printfn "Введите натуральное число"
    int(Console.ReadLine())
    

let rec numbers n =
        if n < 10
        then 1
        else 1 + numbers (n/10)

[<EntryPoint>]
let main _ =
    let n = input
    if n < 0
    then printf "Число не натуральное"
    else printfn "Кол-во цифр в числе: %i" (numbers n)
    0