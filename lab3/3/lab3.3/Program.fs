open System
open System.IO

//3.3 Вывести первый по алфавиту файл в указанном каталоге

let FirstFileAlphab (path: string) : string option =
    try
        if not (Directory.Exists path) then None
        else
            Directory.EnumerateFiles(path)                                                  
            |> Seq.map (fun p -> Path.GetFileName p)                                        
            |> Seq.sortWith (fun a b -> StringComparer.OrdinalIgnoreCase.Compare(a, b))     
            |> Seq.tryHead                                                                  
    with
    | :? UnauthorizedAccessException -> None
    | :? IOException -> None
    | _ -> None

[<EntryPoint>]
let main _ =
    printfn "Введите кателог для поиска файла"
    let dir = Console.ReadLine()
    match FirstFileAlphab(dir) 
    with
    | Some s -> printfn "Первый по алфавиту файл: %s" s
    | None -> printfn "Файл не найден или нет доступа к каталогу"
    0