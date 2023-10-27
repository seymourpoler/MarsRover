package rover

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class MarsRoversApiApplication

fun main(args: Array<String>) {
	runApplication<MarsRoversApiApplication>(*args)
}
