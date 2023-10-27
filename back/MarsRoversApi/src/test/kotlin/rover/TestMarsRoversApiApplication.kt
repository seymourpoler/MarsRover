package rover.rover

import org.springframework.boot.fromApplication
import org.springframework.boot.test.context.TestConfiguration
import org.springframework.boot.with
import rover.MarsRoversApiApplication

@TestConfiguration(proxyBeanMethods = false)
class TestMarsRoversApiApplication

fun main(args: Array<String>) {
	fromApplication<MarsRoversApiApplication>().with(TestMarsRoversApiApplication::class).run(*args)
}
