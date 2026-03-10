
open System
open System.Numerics

//3.1 Получить список из максимальных цифр натуральных чисел, содержащихся в исходном списке

let tryParseNatural (s: string) : BigInteger option =
    if s = "" 
    then 
        None
    elif not (Seq.forall Char.IsDigit s) 
    then 
        None
    else
        let value = BigInteger.Parse s
        if value > BigInteger.Zero 
        then 
            Some value 
        else None

let isNatural (s: string) : bool =
    Option.isSome (tryParseNatural s)

    

let rec input ()=
    printfn "Создание последовательности\nВведите кол-во эл. последовательности"
    let s = Console.ReadLine()
    if(isNatural s)
    then
        let n = int(s)
        seq {
        for i in 1..n do
            printfn "Введите натуральное число"
            let str = Console.ReadLine()
            if(isNatural str)
            then
                int(str)
        }
    else
        printfn "Невозможно создать последовательность"
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

let max_figure s1 = Seq.map (fun x -> search x 0) s1

[<EntryPoint>]
let main _ =
    let s0 = input () |> Seq.cache
    s0 |> Seq.iter (fun _ -> ())
    let s1 = max_figure s0 
    printf "Список максимальных цифр: " 
    s1 |> Seq.iter (printf "%i ")
    0