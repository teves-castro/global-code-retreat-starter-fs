module Tests

open Expecto

[<Tests>]
let tests =
  testList "tests" [
    testCase "sanity check" <| fun _ ->
      Expect.isTrue true "should not fail"
  ]
