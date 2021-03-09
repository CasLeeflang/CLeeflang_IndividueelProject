var TimeSlotList = [];


function submitForm() {
    // Get the first form with the name 
    var frm = document.getElementsByName('TimeSlotForm')[0];
    TimeSlotList.push(frm);
    document.write(frm);
} 