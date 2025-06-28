package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

// 查找控制台中重复输入行
func consulRepetition() {
	countMap := make(map[string]int)
	input := bufio.NewScanner(os.Stdin)

	for input.Scan() {
		countMap[input.Text()]++
	}

	for line, count := range countMap {
		if count > 1 {
			fmt.Printf("%s 共出现了 %d 次\n", line, count)
		}
	}
}

// 查找文件中重复输入的行
func fileRepetition() {
	countMap := make(map[string]int)
	filePaths := os.Args[1:]

	for _, filePath := range filePaths {
		if len(filePath) <= 0 {
			continue
		}
		f, err := os.Open(filePath)
		if err != nil {
			fmt.Printf("打开文件%s时发生异常%v\n", filePath, err)
			continue
		}
		countLines(f, countMap)
		f.Close()
	}

	for line, count := range countMap {
		if count > 1 {
			fmt.Printf("%s 共出现了 %d 次\n", line, count)
		}
	}
}

// 统计文件中每行内容出现的次数
// f 文件指针
// countMap 行内容与出现次数的Map
func countLines(f *os.File, countMap map[string]int) {
	input := bufio.NewScanner(f)
	for input.Scan() {
		countMap[input.Text()]++
	}
}

// 查找文件中重复输入的行
func fileRepetition2() {
	countMap := make(map[string]int)
	filePaths := os.Args[1:]

	for _, filePath := range filePaths {
		countLines2(filePath, countMap)
	}

	for line, count := range countMap {
		if count > 1 {
			fmt.Printf("%s 共出现了 %d 次\n", line, count)
		}
	}
}

// 根据文件名读取文件内容
func countLines2(filePath string, countMap map[string]int) {
	if len(filePath) <= 0 {
		return
	}

	content, err := os.ReadFile(filePath)
	if err != nil {
		fmt.Fprintf(os.Stdin, "打开文件%s时发生错误%v\n", filePath, err)
	}

	for _, line := range strings.Split(string(content), "\r\n") {
		countMap[line]++
	}
}
