package main

import (
	"fmt"
	"time"
)

func main() {
	go spinner(100 * time.Millisecond)
	n := 45
	f := fib(n)
	fmt.Printf("\r结果为(%d)=%d\n", n, f)
}

func spinner(delay time.Duration) {
	for {
		// for _, v := range `-\|/` {
		for _, v := range "-\\|/" {
			// fmt.Printf("\r%c", v)
			fmt.Printf("%c\b", v)
			time.Sleep(delay)
		}
	}
}

func fib(x int) int {
	if x < 2 {
		return x
	}
	return fib(x-1) + fib(x-2)
}
