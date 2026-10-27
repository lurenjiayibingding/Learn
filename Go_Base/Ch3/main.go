package main

import (
	"fmt"

	"example.com/base/Ch3/typepractice"
)

func main() {
	// o := 0666
	// fmt.Printf("%d %[1]o %[1]c %[1]q %#[1]o %[1]x %#[1]x\n", o)

	// x := int64(0xdeadbeef)
	// fmt.Printf("%d %[1]o %#[1]o %[1]x %#[1]x\n", x)

	// ascii := 'a'
	// unicode := '国'
	// newline := '\n'
	// fmt.Printf("%d %[1]o %[1]c %[1]q\n", ascii)
	// fmt.Printf("%d %[1]o %[1]c %[1]q\n", unicode)
	// fmt.Printf("%d %[1]o %[1]c %[1]q\n", newline)

	var f float32 = 16777216
	fmt.Print(f)
	fmt.Print(f + 1)
	fmt.Println(f == f+1)

	typepractice.GetIndexByte()
}
