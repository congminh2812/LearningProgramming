import axiosClient, { withErrorHandling } from "./axiosClient"

const messageApi = {
    getChatUsersByUserId: withErrorHandling(async() => {
        const response = await axiosClient.get('/Message/getChatUsersByUserId')
        
        return response.data
    }),
}

export default messageApi