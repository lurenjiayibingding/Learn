package main

import (
	"fmt"
	"io"
	"log"
	"net/http"
	"sync"
)

var (
	count int
	mu    sync.Mutex
)

// 监听指定端口的http请求
func listenPort() {
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprintf(w, "URL.Path=%q\n", r.URL.Path)
		mu.Lock()
		count++
		mu.Unlock()
	})
	http.HandleFunc("/print", printRequest)
	http.HandleFunc("/count", countHandle)
	http.HandleFunc("/gif", printGif)
	log.Fatal(http.ListenAndServe("localhost:8080", nil))
}

func countHandle(w http.ResponseWriter, r *http.Request) {
	mu.Lock()
	fmt.Fprintf(w, "页面访问次数:%d", count)
	mu.Unlock()
}

// func printRequest(r *http.Request) {
// 	// 打印请求头
// 	fmt.Println("请求头:")
// 	for name, values := range r.Header {
// 		for _, value := range values {
// 			fmt.Printf("%s: %s\n", name, value)
// 		}
// 	}

// 	// 打印请求Body
// 	fmt.Println("请求Body:")
// 	if r.Body != nil {
// 		defer r.Body.Close()
// 		body, err := io.ReadAll(r.Body)
// 		if err != nil {
// 			fmt.Println("读取Body出错:", err)
// 			return
// 		}
// 		fmt.Println(string(body))
// 	} else {
// 		fmt.Println("无Body内容")
// 	}
// }

// 输出请求中的请求头和Body信息
func printRequest(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "%s %s %s \n", r.Method, r.URL, r.Proto)
	for k, v := range r.Header {
		fmt.Fprintf(w, "请求头【%q】=%q\n", k, v)
	}

	fmt.Fprintf(w, "Host=%q\n", r.Host)
	fmt.Fprintf(w, "RemoteAddr=%q\n", r.RemoteAddr)

	if err := r.ParseForm(); err != nil {
		log.Print(err)
		// log.Fatal(err)
	}

	for k, v := range r.Form {
		fmt.Fprintf(w, "From【%q】=%q\n", k, v)
	}

	body, err := io.ReadAll(r.Body)
	if err != nil {
		log.Printf("获取Body时异常：%s\n", err)
	}
	fmt.Fprintf(w, "请求体=%q\n", string(body))
	defer r.Body.Close()
}

// 在页面上输出一个Gif动图
func printGif(w http.ResponseWriter, r *http.Request) {
	lissajous(w)
}
