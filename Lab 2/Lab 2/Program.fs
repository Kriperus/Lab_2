open System
open Microsoft.FSharp.Core

let rec createList () = // Создание списка
    let element = Console.ReadLine()    // Задания значений списка
    if element = "" then    // Если введена пустота то создается пустой список
        []
    else
        element :: createList() // Рекурсивный вызов

let addToList element list = element :: list  // Добавление элемента в лист

let lastChar list =
    for i in 0..List.length list-1 do
            let it = list[i]
            let last = it.ToString().[it.ToString().Length-1]
            let num = Int64.Parse(last.ToString())
        num
    

[<EntryPoint>]
let main argv =
    printfn "Введите список: "
    let list = createList()
    printf "%A" list
    let temp = []
    
    let result = lastChar list :: temp
    
    printfn "Искомый список: %A" result
    0
