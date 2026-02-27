const readline = require('readline');

// Set up the console input/output interface
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Monthly Working Days
function getMonthlyWorkingDays(dateInput) {
    const date = new Date(dateInput);
    if (isNaN(date.getTime())) {
        return { error: "Invalid date provided. Please use a valid format like YYYY-MM-DD." };
    }

    const year = date.getFullYear();
    const month = date.getMonth();
    const totalDaysInMonth = new Date(year, month + 1, 0).getDate();

    let workingDays = 0;
    let nonWorkingDays = 0;

    for (let day = 1; day <= totalDaysInMonth; day++) {
        const dayOfWeek = new Date(year, month, day).getDay();
        if (dayOfWeek === 0 || dayOfWeek === 6) {
            nonWorkingDays++;
        } else {
            workingDays++;
        }
    }

    return {
        month: date.toLocaleString('default', { month: 'long' }),
        year: year,
        totalDays: totalDaysInMonth,
        workingDays: workingDays,
        nonWorkingDays: nonWorkingDays
    };
}

    rl.question('2. Enter a date to calculate working days (e.g., 2026-02-26): ', (dateInput) => {
        
        const daysInfo = getMonthlyWorkingDays(dateInput);
        console.log('\n--- Working Days Result ---');
        console.log(daysInfo);
        console.log('---------------------------\n');

        // Prevent Quick Exit
        rl.question('Challenge complete! Press Enter to exit the console...', () => {
            rl.close();
        });
    });