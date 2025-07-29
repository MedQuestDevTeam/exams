wordFrequency("apple banana apple orange banana apple")
// 输出：apple: 3, banana: 2, orange: 1
function wordFrequency(text) {
    const words = text.toLowerCase().match(/\b\w+\b/g); // 提取单词
    const freq = {};

    for (let word of words) {
        freq[word] = (freq[word] || 0) + 1;
    }

    const sorted = Object.entries(freq).sort((a, b) => b[1] - a[1]);

    for (let [word, count] of sorted) {
        console.log(`${word}: ${count}`);
    }
    return sorted;
}

