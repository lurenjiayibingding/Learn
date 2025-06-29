package tempconv

import (
	"fmt"
	"strconv"
)

// 摄氏温度转为华氏温度
func CToF(c Celsius) Fahrenheit {
	return Fahrenheit(c*9/5 + 32)
}

// 华氏温度转为摄氏温度
func FToC(f Fahrenheit) Celsius {
	return Celsius((f - 32) * 5 / 9)
}

// 英里转换为米
func MileToMeter(m Mile) Meter {
	return Meter(m * MeterScale)
}

// 米转换为英里
func MeterToMile(m Meter) Mile {
	return Mile(m / MeterScale)
}

// 将输入的英里转为米
func InputDistanceConvert(input string) {
	m1, err := strconv.ParseFloat(input, 64)
	if err != nil {
		fmt.Printf("输入的数据转为浮点数时出错:%v\n", err)
		return
	}
	m2 := MileToMeter(Mile(m1))
	fmt.Printf("%s英里等于%.4f米\n", input, m2)
}
