export interface NavigationMenu {
 id: number
 parentId?: number
 name: string
 url: string
 icon: string
 position: number
 children: NavigationMenu[]
}

export interface CreateNavigationMenu {
 parentId?: number
 name: string
 url: string
 icon: string
 position: number
}

export interface UpdateCreateNavigationMenu {
 id: number
 name: string
 url: string
 icon: string
 position: number
}
