
open System
open System.Numerics

///3.2 Список содержит строки. Найти суммарную длину этих строк.

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
            printfn "Введите элемент"
            Console.ReadLine()
        }
    else
        printfn "Невозможно создать последовательность"
        input ()

let Length_sum l1 = Seq.fold (fun acc (x:string) -> acc + x.Length) 0 l1

[<EntryPoint>]
let main _ =
    let s0 = input () |> Seq.cache
    s0 |> Seq.iter (fun _ -> ())
    let s1 = Length_sum s0 
    printf "Суммарная длина строк: %i"  s1
    0