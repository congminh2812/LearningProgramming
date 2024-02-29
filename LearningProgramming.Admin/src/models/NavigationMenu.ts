export interface NavigationMenu {
 id: number
 parentId?: number
 name: string
 url: string
 icon: string
 position: number
 children: NavigationMenu[]
}
