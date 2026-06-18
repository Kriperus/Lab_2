open system

let rec tryParseFloat (input: string) =
    match System.Double.TryParse(input) with
    | (true, value) -> Some value
    | _ -> None

let getLastDigit (x: float) =
    let str = string x
    let len = String.length str
    let lastChar = str.[len - 1]
    int (string lastChar)

let rec inputList () =
    printf "Введите вещественное число (или 'stop' для завершения): "
    let input = System.Console.ReadLine()
    match input.ToLower() with
    | "stop" -> []
    | _ ->
        match tryParseFloat input with
        | Some num ->
            printfn "Число %f принято" num
            num :: inputList ()
        | None ->
            printfn "Ошибка! Введите корректное вещественное число или 'stop'"
            inputList ()

let rec checkRange (numbers: float list) (minVal: float) (maxVal: float) =
    match numbers with
    | [] -> true
    | head :: tail ->
        if head >= minVal && head <= maxVal then
            checkRange tail minVal maxVal
        else
            false

let rec printList (lst: int list) =
    match lst with
    | [] -> printfn ""
    | head :: [] -> printf "%d\n" head
    | head :: tail ->
        printf "%d, " head
        printList tail

[<EntryPoint>]
let main argv =
    printfn "Диапазон допустимых значений: от -1000 до 1000\n"
    
    let numbers = inputList ()
    
    printfn "\nВведённый список: %A" numbers
    
    let minVal = -1000.0
    let maxVal = 1000.0
    
    if checkRange numbers minVal maxVal then
        printfn "Все числа в допустимом диапазоне [%f, %f]" minVal maxVal
        
        let result = List.map getLastDigit numbers
        
        printf "Последние цифры: "
        printList result
    else
        printfn "Ошибка! Обнаружены числа вне диапазона [%f, %f]" minVal maxVal
        printfn "Программа завершена."
    
    0
