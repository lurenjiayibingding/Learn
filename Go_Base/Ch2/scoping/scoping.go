package scoping

import (
	"fmt"
)

// 小写转大写
func LowToUpper1() {
	x := "Hello!"
	for i := 0; i < len(x); i++ {
		x := x[i]
		if x != '!' {
			x := x + 'A' - 'a'
			fmt.Printf("%c\n", x)
			fmt.Printf("%d\n", &x)
		}
	}
}

// 小写转大写
func LowToUpper2() {
	x := "Hello!"
	for _, x := range x {
		if x != '!' {
			x := x + 'A' - 'a'
			fmt.Printf("%c\n", x)
		}
	}
}
