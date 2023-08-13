function isWeekend(day) {
    return day.getDay() === 0 || day.getDay() === 6; // Sunday or Saturday
  }
  
  function calculateDays() {
    const inputDate = new Date(document.getElementById('inputDate').value);
    const firstDayOfMonth = new Date(inputDate.getFullYear(), inputDate.getMonth(), 1);
    
    let workingDays = 0;
    let nonWorkingDays = 0;
  
    for (let day = new Date(firstDayOfMonth); day <= inputDate; day.setDate(day.getDate() + 1)) {
      if (!isWeekend(day)) {
        workingDays++;
      } else {
        nonWorkingDays++;
      }
    }
  
    const resultElement = document.getElementById('result');
    resultElement.innerHTML = `Working Days: ${workingDays}<br>Non-Working Days: ${nonWorkingDays}`;
  }
  