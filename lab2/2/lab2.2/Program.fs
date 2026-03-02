open System

//2.2 Список содержит строки. Найти суммарную длину этих строк.

let rec input ()=
    printfn "Создание списка\nВведите кол-во эл. списка"
    let n = int(Console.ReadLine())
    if n >= 0
    then
        [
        for i in 1..n do
            printfn "Введите эл. списка"
            yield Console.ReadLine()
        ]
    else
        printfn "Невозможно создать список"
        input ()

let Length_sum l1 = List.fold (fun acc (x:string) -> acc + x.Length) 0 l1


[<EntryPoint>]
let main _ =
    let n = input ()
    printfn "Суммарная длина всех элементов списка: %i" (Length_sum n)
    0
