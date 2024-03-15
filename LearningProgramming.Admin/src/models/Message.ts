export type Message = {
 id: number
 content: string
 createdAt: Date
 unread: boolean
 senderId: number
 receiverId: number
}

export type ChatUser = {
 fullName: string
 content: string
 createdAt: Date
 unread: boolean
 receiverId: number
 avatar: string
}
