const readline = require('readline');

// Set up the console input/output interface
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

    function getSortedWordFrequencies(text) {
        if (typeof text !== 'string' || text.trim() === '') {
            return [];
        }

        // Extract words using a regular expression (ignores punctuation)
        const words = text.toLowerCase().match(/\b\w+\b/g);

        if (!words) {
            return [];
        }

        // Count occurrences using an object
        const wordCounts = {};
        for (const word of words) {
            wordCounts[word] = (wordCounts[word] || 0) + 1;
        }

        // Convert to an array, sort descending by count, and format output
        const sortedFrequencies = Object.entries(wordCounts)
            .sort((a, b) => b[1] - a[1])
            .map(([word, count]) => ({ word, count }));

        return sortedFrequencies;
    }

    // Word Counter
    rl.question('1. Enter a sentence to count word frequencies: ', (textInput) => {

        const frequencies = getSortedWordFrequencies(textInput);
        console.log('\n--- Word Frequencies Result ---');
        console.log(frequencies);
        console.log('-------------------------------\n');

        // Prevent Quick Exit
        rl.question('Challenge complete! Press Enter to exit the console...', () => {
            rl.close();
        });
    });
