#!/bin/bash

# GPIO24(18番ピン)の使用開始
echo "24" > /sys/class/gpio/export

# GPIO24を出力に設定
echo "out" > /sys/class/gpio/gpio24/direction

# 5回ループする
for i in 1 2 3 4 5
do
    # LED点灯
    echo "1" > /sys/class/gpio/gpio24/value

    sleep 1

    # LED消灯
    echo "0" > /sys/class/gpio/gpio24/value

    sleep 1
done

# GPIO24の使用終了を宣言
echo "24" > /sys/class/gpio/unexport

