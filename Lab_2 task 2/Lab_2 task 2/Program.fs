open System

// ввод символов с клавиатуры
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
        
        // List.fold
        let resultString = 
            chars 
            |> List.fold (fun acc char -> acc + string char) ""
        
        printfn "Результирующая строка: \"%s\"" resultString
        
        printfn "\nПошаговое выполнение List.fold:"
        
        chars
        |> List.fold (fun (step, acc) char ->
            let newAcc = acc + string char
            printfn "  Шаг %d: добавляем '%c' -> \"%s\"" step char newAcc
            (step + 1, newAcc)
        ) (1, "")
        |> ignore
    0