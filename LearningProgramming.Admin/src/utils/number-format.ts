export const numberFormat = (number: number) => {
 return number.toLocaleString('en-us', { minimumFractionDigits: 2 })
}

export const numberToText = (num: number) => {
 const absNum = Math.abs(num)
 const suffixes = ['', 'K', 'M', 'B', 'T']
 const suffixIndex = Math.floor(Math.log10(absNum) / 3) // Determine the appropriate suffix
 const truncatedNum = num / Math.pow(10, suffixIndex * 3) // Divide the number by 10^(3 * suffixIndex) to get the truncated number

 // Format the number with the appropriate suffix
 const formattedNum = truncatedNum.toFixed(2).replace(/\.0+$|(\.[0-9]*[1-9])0+$/, '$1')

 return num >= 0 ? formattedNum + suffixes[suffixIndex] : '-' + formattedNum + suffixes[suffixIndex]
}
