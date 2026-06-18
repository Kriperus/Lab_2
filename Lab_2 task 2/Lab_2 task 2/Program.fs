open System

let rec readCharsTailRec acc =
    printf "Введите символ (или 'exit' для завершения): "
    
    match Console.ReadLine() with
    | input when input.ToLower() = "exit" -> 
        List.rev acc
    | input ->
        match input.Length with
        | 1 ->
            let char = input.[0]
            printfn "Добавлен символ: '%c'" char
            readCharsTailRec (char :: acc)
        | 0 ->
            printfn "Ошибка: введена пустая строка! Введите один символ."
            readCharsTailRec acc
        | _ ->
            printfn "Ошибка: введите ровно один символ!"
            readCharsTailRec acc

let foldWithLogging chars =
    let mutable step = 1
    let result = 
        chars 
        |> List.fold (fun acc char ->
            let newAcc = acc + string char
            printfn "  Шаг %d: добавляем '%c' -> \"%s\"" step char newAcc
            step <- step + 1
            newAcc
        ) ""
    result

[<EntryPoint>]
let main argv =
    printfn "Вводите символы по одному"
    printfn "Для завершения введите 'exit'\n"

    let chars = readCharsTailRec []
    
    match chars with
    | [] -> 
        printfn "\nСписок символов пуст!"
    | _ ->
        printfn "\nИсходный список символов: %A" chars
        
        printfn "\nПошаговое выполнение List.fold:"
        let resultString = foldWithLogging chars
        
        printfn "\nРезультирующая строка: \"%s\"" resultString
    
    0
