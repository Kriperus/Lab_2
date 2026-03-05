open System
open Microsoft.FSharp.Core

let rec createList () = // Создание списка
    let element = Console.ReadLine()    // Задания значений списка
    if element = "" then    // Если введена пустота то создается пустой список
        []
    else
        element :: createList() // Рекурсивный вызов

[<EntryPoint>]
let main argv =
    printfn "Введите элементы вашего списка: "  // Функция для создание списка
    let list = createList()
    let result = System.String.Concat(Array.ofList(list))
    printf "Нужная строка: %s" result
    0
