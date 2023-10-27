package rover

import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RestController

@RestController
@RequestMapping("/api/movement")
class MoveController {
    @PostMapping
    fun move(@RequestBody command : Command) : ResponseEntity<Void> {
        throw NotImplementedError()
    }
}
