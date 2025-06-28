package tempconv

import "fmt"

// 摄氏温度
type Celsius float64

// 华氏温度
type Fahrenheit float64

const (
	//摄氏温度下的绝对零度
	AbsoluteZeroC Celsius = -273.15
	//摄氏温度下的零度
	FreezingC Celsius = 0
	//摄氏温度下的沸点
	BoilingC Celsius = 100
)

func (c Celsius) String() string {
	return fmt.Sprintf("%g°C", c)
}

func (f Fahrenheit) String() string {
	return fmt.Sprintf("%g°F", f)
}
