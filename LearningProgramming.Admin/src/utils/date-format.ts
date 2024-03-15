import moment from "moment"

export const dateFormat = (date: Date, format: string) => {
    return moment(date).format(format)
} 