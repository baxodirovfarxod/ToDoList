// DOM elementlari
const form = document.getElementById("delete-form");
const input = document.getElementById("task-id");
const responseMessage = document.getElementById("response-message");

// Vazifani o'chirish (API orqali)
async function deleteTask(taskId) {
  try {
    // API so‘rovi orqali vazifani o‘chirish
    const response = await fetch(`http://localhost:5195/api/toDoList/delete?id=${taskId}`, {
      method: 'DELETE',  // DELETE so'rovini yuboramiz
    });

    if (response.ok) {
      responseMessage.textContent = `Vazifa ${taskId} o'chirildi.`;
      responseMessage.style.color = "green";  // Yashil rangda muvaffaqiyatli xabar
    } else {
      responseMessage.textContent = "Xatolik yuz berdi. Iltimos, qayta urinib ko'ring.";
      responseMessage.style.color = "red";  // Qizil rangda xatolik xabari
    }
  } catch (error) {
    console.error("Xatolik: ", error);
    responseMessage.textContent = "Xatolik yuz berdi. Iltimos, qayta urinib ko'ring.";
    responseMessage.style.color = "red";  // Xatolik uchun qizil rang
  }
}

// Formani yuborishni boshqarish
form.addEventListener("submit", function (event) {
  event.preventDefault();

  const taskId = input.value.trim();

  if (taskId !== "") {
    deleteTask(taskId);  // IDni backendga yuborish
    input.value = "";  // Inputni tozalash
  } else {
    responseMessage.textContent = "IDni kiriting.";
    responseMessage.style.color = "red";
  }
});
