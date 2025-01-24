# Manual de Uso para Git desde Cero hasta GitHub

Este manual explica cómo configurar un repositorio desde cero, realizar commits, manejar ramas, y subir tu proyecto a GitHub, incluyendo un ejemplo práctico con un archivo `index.html`.

---

## **1. Configuración Inicial de Git**

### **1.1. Instalar Git**
Descarga e instala Git desde [git-scm.com](https://git-scm.com/).

### **1.2. Configurar Git**
Configura tu nombre y correo electrónico:
```bash
git config --global user.name "Tu Nombre"
git config --global user.email "tuemail@example.com"
```
---

## **2. Inicializar un Repositorio Local**

1. Crea una carpeta para tu proyecto:
   ```bash
   mkdir mi_proyecto
   cd mi_proyecto
   ```
2. Inicializa el repositorio:
   ```bash
   git init
   ```

---

## **3. Crear y Confirmar Cambios**

1. Crea un archivo `index.html`:
   ```html
   <html>
   <head>
       <title>Mi Proyecto</title>
   </head>
   <body>
       <h1>¡Hola Mundo!</h1>
   </body>
   </html>
   ```
2. Añade el archivo al área de preparación:
   ```bash
   git add index.html
   ```
3. Realiza un commit:
   ```bash
   git commit -m "Primera versión de index.html"
   ```

---

## **4. Configurar un Repositorio Remoto en GitHub**

1. Crea un repositorio en GitHub (por ejemplo, `mi_proyecto`).
2. Añade el repositorio remoto:
   ```bash
   git remote add origin https://github.com/tu-usuario/mi_proyecto.git
   ```
3. Verifica el repositorio remoto:
   ```bash
   git remote -v
   ```

---

## **5. Subir Cambios a GitHub**

1. Sube los cambios iniciales a la rama principal (`main` o `master`):
   ```bash
   git push -u origin main
   ```
   Si tu rama principal se llama `master`, usa:
   ```bash
   git push -u origin master
   ```

---

## **6. Manejo de Ramas**

### **6.1. Crear una Nueva Rama**
Crea y cambia a una nueva rama:
```bash
git checkout -b nueva_rama
```

### **6.2. Realizar Cambios en la Nueva Rama**
Edita `index.html` para añadir un subtítulo:
```html
<h2>Subtítulo en la nueva rama</h2>
```
Realiza un commit:
```bash
git add index.html
git commit -m "Añadido subtítulo en nueva_rama"
```

### **6.3. Subir la Nueva Rama a GitHub**
Sube la rama al repositorio remoto:
```bash
git push -u origin nueva_rama
```

### **6.4. Cambiar Entre Ramas**
Para regresar a la rama principal:
```bash
git checkout main
```

---

## **7. Clonar un Repositorio**
Si quieres clonar un repositorio existente de GitHub:
```bash
git clone https://github.com/tu-usuario/mi_proyecto.git
```

---

## **8. Resolver Errores Comunes**

### **Error: src refspec main does not match any**
Este error ocurre si la rama `main` no existe o no tiene commits. Solución:
```bash
git checkout -b main
# Añade archivos y realiza un commit
# Luego realiza el push
```

### **Error: 'origin' does not appear to be a git repository**
Este error ocurre si no has configurado un repositorio remoto. Solución:
```bash
git remote add origin <URL-del-repositorio>
git push -u origin main
```

---

Con estos pasos podrás manejar tu proyecto desde cero hasta tenerlo alojado en GitHub, incluyendo el manejo de ramas. ¡Buena suerte!
