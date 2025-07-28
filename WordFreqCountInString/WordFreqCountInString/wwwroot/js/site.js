function countWords() {
    const text = document.getElementById("inputText").value;

    const cleaned = text.replace(/[^\w\s]/gi, '').toLowerCase();
    const words = cleaned.split(/\s+/);

    const frequencyMap = {};
    for (let word of words) {
        if (word) {
            frequencyMap[word] = (frequencyMap[word] || 0) + 1;
        }
    }

    const sorted = Object.entries(frequencyMap)
        .sort((a, b) => b[1] - a[1]);

    const resultList = document.getElementById("resultList");
    resultList.innerHTML = "";

    sorted.forEach(([word, count]) => {
        const li = document.createElement("li");
        li.textContent = `${word}: ${count}`;
        resultList.appendChild(li);
    });
}
