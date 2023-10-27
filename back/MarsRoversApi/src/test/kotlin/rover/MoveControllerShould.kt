package rover.rover

import com.fasterxml.jackson.databind.ObjectMapper
import org.junit.jupiter.api.Test
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.http.MediaType
import org.springframework.test.web.servlet.MockMvc
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post
import org.springframework.test.web.servlet.result.MockMvcResultMatchers.status

class MoveControllerShould {
    @Autowired
    lateinit var mockMvc: MockMvc
    lateinit var objectMapper: ObjectMapper

    @Test
    fun `move to`(){
        mockMvc.perform(
            post("/api/movement")
                .contentType(MediaType.APPLICATION_JSON)
                .content("{ \"value\" : \"F\"}")
                //.content(objectMapper.writeValueAsString(personaActualizada))
        )
            .andExpect(status().isOk)
    }
}