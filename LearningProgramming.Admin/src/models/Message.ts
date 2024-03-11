export type Message = {
 id: number
 content: string
 createdDate: Date
 unread?: boolean
 userId: number
 senderId: number
}

export type ChatUser = {
 fullName: string
 content: string
 createdDate: Date
 unread?: boolean
 senderId: number
}
