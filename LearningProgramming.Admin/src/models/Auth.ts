export interface LoginModel {
 email: string
 password: string
 persistent: boolean
}

export interface TokenModel {
 accessToken: string
 refreshToken: string
}

export interface RegisterModel {
 email: string
 password: string
 firstName: string
 lastName: string
}
