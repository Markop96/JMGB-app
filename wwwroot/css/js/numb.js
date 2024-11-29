
function validateNumberInput(inputIndex) {
    const input = document.getElementById(`input${inputIndex}`);
    input.value = input.value.replace(/[^0-9]/g, '');

    if (input.value.length === 1 && inputIndex < 13) {
        const nextInput = document.getElementById(`input${inputIndex + 1}`);
        nextInput.focus();
    }

    if (input.value.length === 0 && inputIndex > 1) {
        const previousInput = document.getElementById(`input${inputIndex - 1}`);
        previousInput.focus();
    }

}

function validateNameInput(event) {
    event.target.value = event.target.value.replace(/[^a-zA-ZčČćĆšŠžŽđĐžć]/g, '');
}

function validateForm() {
    const ime = document.getElementById("floatingInputIme").value;
    const prezime = document.getElementById("floatingInputPrezime").value;

    let jmbgPopunjen = true;
    for (let i = 1; i <= 13; i++) {
        if (document.getElementById(`input${i}`).value === '') {
            jmbgPopunjen = false;
            break;
        }
    }
    const searchButton = document.getElementById("searchButton");
    if (ime !== '' && prezime !== '' && jmbgPopunjen) {
        searchButton.disabled = false;
    } else {
        searchButton.disabled = true;
    }
}
