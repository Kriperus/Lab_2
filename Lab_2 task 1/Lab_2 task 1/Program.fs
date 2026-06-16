open System

// Получение последней цифры вещественного числа
let getLastDigit (num: float) =
    num.ToString()
    |> Seq.filter Char.IsDigit
    |> Seq.last
    |> string
    |> int

// Хвостовая рекурсия для ввода чисел с клавиатуры
let rec readNumbersTailRec acc =
    printf "Введите число (или 'exit' для завершения): "
    
    match Console.ReadLine() with
    | input when input.ToLower() = "exit" -> 
        List.rev acc
    | input ->
        match Double.TryParse input with
        | true, num ->
            printfn "Добавлено: %.2f" num
            readNumbersTailRec (num :: acc)
        | false, _ ->
            printfn "Ошибка ввода! Попробуйте снова."
            readNumbersTailRec acc

[<EntryPoint>]
let main argv =
    printfn "=== Программа получения последних цифр ==="
    printfn "Вводите вещественные числа по одному"
    printfn "Для завершения введите 'exit'\n"
    
    // Чисто функциональный ввод чисел
    let numbers = readNumbersTailRec []
    
    match numbers with
    | [] -> 
        printfn "\nНе введено ни одного числа!"
    | _ ->
        printfn "\nИсходный список: %A" numbers
        
        // Применение List.map для получения последних цифр
        let lastDigits = 
            numbers 
            |> List.map getLastDigit
        
        printfn "Последние цифры: %A" lastDigits
        
        // Демонстрация преобразования
        printfn "\nДетали преобразования:"
        
        List.zip numbers lastDigits
        |> List.iter (fun (num, digit) -> 
            printfn "  %.2f -> %d" num digit)
    
    printfn "\nНажмите любую клавишу для выхода..."
    Console.ReadKey() |> ignore
    0
