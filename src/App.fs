module Life

open Fable.Core.JsInterop
open Fable.Import
open Browser

let canvasWidth = 550.
let canvasHeight = 550.

let canvas = document.getElementsByTagName_canvas().[0]
canvas.width <- canvasWidth
canvas.height <- canvasHeight
let ctx = canvas.getContext_2d()

let clear () =
    ctx.clearRect (0., 0., canvasWidth, canvasHeight)

let drawSquare style (x,y) width =
    ctx.fillStyle <- style
    ctx.fillRect (x,y, width, width)

let rgb r g b : Fable.Core.U3<string,CanvasGradient,CanvasPattern> =
    !^ (sprintf "rgb(%d,%d,%d)" r g b)

let rgba r g b a : Fable.Core.U3<string,CanvasGradient,CanvasPattern> =
    !^ (sprintf "rgba(%d,%d,%d,%d)" r g b a)

let drawBoard i =
    for y in 0 .. 80 do
    for x in 0 .. 80 do
        let style = rgb ((x+i) % 255) ((y+i) % 255) 0
        drawSquare style (float x * 10., float y * 10.) 10.

let rec draw i = async {
    clear ()
    drawBoard i
    do! Async.Sleep(int (1000. / 10.))
    do! draw (i+1)
}

draw 0 |> Async.StartImmediate
