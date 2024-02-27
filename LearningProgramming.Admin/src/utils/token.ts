export const decodeAccessToken = (accessToken: string): { [key: string]: any } | null => {
 try {
  const payloadBase64 = accessToken.split('.')[1]
  const decodedPayload = atob(payloadBase64)
  const parsedPayload = JSON.parse(decodedPayload)
  return parsedPayload
 } catch (error) {
  console.error('Error parsing access token:', error)
  return null
 }
}
