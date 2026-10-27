package typepractice

import "fmt"

func getLen(s string) int {
	return len(s)
}

//吃葡萄不吐葡萄皮
func GetIndexByte() {
	s := "吃葡萄不吐葡萄皮"
	fmt.Println(len(s))
	fmt.Println(s[0], s[7])
	fmt.Println(s[0:7])
	fmt.Println(s[0:9])
}
