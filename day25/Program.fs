// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System 

type Num = uint64

let transform (value:Num) (subjectNum:Num) : Num = (value * subjectNum) % 20201227UL    
let rec transformLoop (value:Num) (subjectNum:Num) (loopSize:Num) : Num =
    if loopSize = 0UL then value
    else transformLoop (transform value subjectNum) subjectNum (loopSize-1UL)

let find_loop_size (pk:Num) : Num =
    let rec find (pk:Num) (value:Num) (n:Num) : Num =
        if value = pk then n
        else find pk (transform 7UL value) (n+1UL)
    find pk 1UL 0UL

let task1 card_pk door_pk =
    let test_card_loop_size = find_loop_size card_pk
    let test_door_loop_size = find_loop_size door_pk
    let test_encryption_key1 = transformLoop 1UL door_pk test_card_loop_size
    let test_encryption_key2 = transformLoop 1UL card_pk test_door_loop_size
    printfn "Loop size: %d" test_card_loop_size
    printfn "Loop size: %d" test_door_loop_size
    printfn "Encryption key: %d %d" test_encryption_key1 test_encryption_key2
    1UL

[<EntryPoint>]
let main argv =
    let test_card_pk = 5764801 |> uint64 
    let test_door_pk = 17807724 |> uint64 
    let actual_card_pk = 14205034 |> uint64
    let actual_door_pk = 18047856 |> uint64
//    let test_ec = task1 test_card_pk test_door_pk
    let encryption_key = task1 actual_card_pk actual_door_pk
//    printfn "Encryption key: %d" encryption_key
 
    
    0 // return an integer exit code