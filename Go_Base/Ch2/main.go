package main

import (
	// "bufio"
	// "fmt"
	// "os"

	// packageinit "example.com/base/Ch2/packageInit"
	// "example.com/base/Ch2/tempconv"
	"example.com/base/Ch2/scoping"
)

func main() {
	// for _, arg := range os.Args[1:] {
	// 	t, err := strconv.ParseFloat(arg, 64)
	// 	if err != nil {
	// 		fmt.Fprintf(os.Stderr, "cf:%v\n", err)
	// 		os.Exit(1)
	// 	}
	// 	f := tempconv.Fahrenheit(t)
	// 	c := tempconv.Celsius(t)

	// 	fmt.Printf("%s=%s,%s=%s\n", f, tempconv.FToC(f), c, tempconv.CToF(c))
	// }

	// if len(os.Args) > 1 {
	// 	for _, input := range os.Args[1:] {
	// 		tempconv.InputDistanceConvert(input)
	// 	}
	// } else {
	// 	scanner := bufio.NewScanner(os.Stdin)
	// 	for scanner.Scan() {
	// 		tempconv.InputDistanceConvert(scanner.Text())
	// 	}
	// }

	// fmt.Printf("Pc2=%v", packageinit.Pc2)

	scoping.LowToUpper1()
	scoping.LowToUpper2()
}
