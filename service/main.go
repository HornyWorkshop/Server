package main

import (
	"os"
)

func main() {
	from := "L:\\[ScrewThisNoise] Koikatsu BetterRepack RX1\\UserData\\chara\\female_old\\genshin\\0f3f8bbef849bb58f2d3b6c3ee53440c01518bcc.png"
	to := "L:\\[ScrewThisNoise] Koikatsu BetterRepack RX1\\UserData\\chara\\female\\0f3f8bbef849bb58f2d3b6c3ee53440c01518bcc_2.png"
	os.Link(from, to)
}
