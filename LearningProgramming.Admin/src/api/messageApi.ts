import axiosClient, { withErrorHandling } from "./axiosClient"

const messageApi = {
    getChatUsersByUserId: withErrorHandling(async() => {
        const response = await axiosClient.get('/Message/getChatUsersByUserId')
        
        return response.data
    }),

    getMessagesByUserId: withErrorHandling(async() => {
        const response = await axiosClient.get('/Message/getMessagesByUserId')
        
        return response.data
    }),

    addMessage: withErrorHandling(async(payload: any) => {
        const response = await axiosClient.post('/Message/add', payload)

        return response.data
    }),

    updateUnreadMessage: withErrorHandling(async(payload: any) => {
        const response = await axiosClient.put(`/Message/updateUnreadMessage/${payload}`)

        return response.data
    })
}

export default messageApi