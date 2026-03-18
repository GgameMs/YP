open System

type BTree<'T> =
    | Node of 'T * BTree<'T> * BTree<'T>
    | Empty

let rec insert (tree: BTree<'T>) (value: 'T) : BTree<'T> =
    match tree with
    | Empty -> Node(value, Empty, Empty)
    | Node(x, left, right) ->
        if compare value x < 0 
        then 
            Node(x, insert left value, right)
        else 
            Node(x, left, insert right value)

let rec mapTree (f: 'T -> 'U) (tree: BTree<'T>) : BTree<'U> =
    match tree with
    | Empty -> Empty
    | Node(x, l, r) -> Node(f x, mapTree f l, mapTree f r)

let printTree (tree: BTree<'T>) =
    let rec loop t depth =
        match t with
        | Empty -> ()
        | Node(x, l, r) ->
            loop l (depth + 1)
            printfn "%s%A" (String.replicate depth "  ") x
            loop r (depth + 1)
    loop tree 0

let nextString (s: string) : string =
    s.ToCharArray() 
    |> Array.map (fun c -> char (int c + 1)) 
    |> fun chars -> String(chars)

let randomAlphaNumString (rnd: Random) (minLen: int) (maxLen: int) : string =
    let charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
    let chars = charset.ToCharArray()
    let length = 
        if maxLen <= minLen 
        then 
            minLen 
        else 
            rnd.Next(minLen, maxLen + 1)
    Array.init length (fun _ -> chars.[rnd.Next(chars.Length)]) |> String

let rec foldTree (f: 'State -> 'T -> BTree<'T> -> BTree<'T> -> 'State) (acc: 'State) (tree: BTree<'T>) : 'State =
    match tree with
    | Empty -> acc
    | Node(x, l, r) ->
        let newAcc = f acc x l r
        let leftAcc = foldTree f newAcc l
        foldTree f leftAcc r
        
let nodesWithTwoLeaves (tree: BTree<'T>): 'T list =
    foldTree (fun acc x l r ->
        match (l,r) with
        | Node(_, Empty, Empty), Node(_, Empty, Empty) -> x :: acc
        | _ -> acc
        ) [] tree

[<EntryPoint>]
let main _ =
    printfn "Введите количество строк"
    let n =
        match Console.ReadLine() with
        | null -> 0
        | s ->
            match Int32.TryParse(s.Trim()) with
            | true, v when v > 0 -> v
            | _ -> 0
    match n with
    | 0 -> printf "Невозможно создать"
    | _ ->
        let minLen = 3
        let maxLen = 12
        let rnd = Random()
        
        let inputs = [ for i in 1..n -> randomAlphaNumString rnd minLen maxLen ]

        printfn "\nСгенерированные строки (%i):" inputs.Length
        inputs |> List.iteri (fun i s -> printfn "%i: %s" (i+1) s)

        let tree = inputs |> List.fold (fun t v -> insert t v) Empty

        printfn "\nДерево до преобразования:"
        printTree tree

        let transformedTree = mapTree nextString tree

        printfn "\nДерево после замены символов на следующий:"
        printTree transformedTree

        let nodesTwoLeaves = nodesWithTwoLeaves tree
        printfn "\nСписок узлов, у которых оба потомка — листья (кол-во = %d):" nodesTwoLeaves.Length
        nodesTwoLeaves |> List.iteri (fun i v -> printfn "%2d: %A" (i+1) v)
    0
