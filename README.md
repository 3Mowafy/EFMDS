# دليل العمل على جزء الـ Views

الملف ده معمول لأي شخص هيشتغل على الواجهة في المشروع، خصوصًا لو دي أول مرة يتعامل مع .NET أو مع مشروع MVC.

## قبل ما تبدأ

لو هتشتغل على المشروع من الصفر، امشِ بالخطوات دي:

1. نزّل وثبّت Visual Studio Code، وده المقصود بـ VS Code الأزرق.
2. نزّل وثبّت .NET SDK 10.0 أو النسخة المتوافقة مع المشروع.
3. نزّل وثبّت Git لو مش موجود على جهازك.
4. اعمل clone للمشروع.
5. افتح المشروع في VS Code.
6. ثبّت الإضافات المطلوبة.
7. شغّل المشروع من الـ terminal.

## عمل clone للمشروع

افتح PowerShell أو Terminal واكتب:

```bash
git clone <REPO_URL>
```

بعدها ادخل على فولدر المشروع:

```bash
cd EFMDS
```

لو المشروع موجود عندك بالفعل، ممكن تتخطى الخطوة دي وتفتح الفولدر مباشرة.

## فتح المشروع في VS Code

من داخل فولدر المشروع اكتب:

```bash
code .
```

لو الأمر `code` مش شغال، افتح VS Code يدويًا ثم:

1. اختار `File`.
2. اختار `Open Folder`.
3. اختار فولدر `EFMDS`.

بعد الفتح، افتح Terminal من داخل VS Code عن طريق:

1. `Terminal`
2. `New Terminal`

## الإضافات المطلوبة داخل VS Code

ثبّت الإضافات دي من Marketplace داخل VS Code:

- C# من Microsoft
- C# Dev Kit من Microsoft
- Razor من Microsoft
- GitLens لو محتاج متابعة تاريخ الـ git
- EditorConfig for VS Code لو حابب التزام أفضل بالتنسيق

ولو الأمر `code` شغال عندك، تقدر تثبّتهم كمان بالأوامر دي:

```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit
code --install-extension ms-dotnettools.razor
code --install-extension eamodio.gitlens
code --install-extension EditorConfig.EditorConfig
```

## معلومات سريعة عن المشروع

المشروع ASP.NET Core MVC، والواجهة مبنية بـ Bootstrap 5 من CDN. أغلب الشغل الخاص بالواجهة موجود داخل:

- `EFMDS.Web/Views/Shared`
- `EFMDS.Web/Views/Home`
- `EFMDS.Web/Views/Specialties`
- `EFMDS.Web/Views/Error`

## تشغيل المشروع

من جذر المشروع شغل الأوامر دي:

```bash
dotnet restore
dotnet run --project EFMDS.Web/EFMDS.Web.csproj
```

ولو أنت واقف داخل فولدر `EFMDS.Web` نفسه:

```bash
dotnet restore
dotnet run
```

بعدها افتح الرابط اللي هيظهر في الـ terminal.

## أوامر مهمة جدًا

دي الأوامر اللي هتستخدمها غالبًا أثناء الشغل:

```bash
dotnet --version
dotnet restore
dotnet build
dotnet run --project EFMDS.Web/EFMDS.Web.csproj
```

## لو `dotnet` مش شغال

لو كتبت `dotnet --version` وظهر خطأ:

1. تأكد إن .NET SDK متثبت.
2. اقفل وافتح VS Code من جديد.
3. جرّب Terminal جديد.
4. تأكد إن المسار PATH متضاف عليه .NET.

## هيكل الـ Views

### الملفات المشتركة

- `Views/Shared/_Layout.cshtml` هو القالب الأساسي لكل الصفحات.
- `Views/Shared/_Navbar.cshtml` فيه شريط التنقل.
- `Views/_ViewStart.cshtml` بيحدد إن كل الصفحات تستخدم الـ layout.

### الصفحات الحالية

- `Views/Home/index.cshtml` الصفحة الرئيسية.
- `Views/Specialties/Index.cshtml` قائمة الـ specialties.
- `Views/Specialties/Create.cshtml` إضافة specialty جديدة.
- `Views/Specialties/Edit.cshtml` تعديل specialty.
- `Views/Specialties/Details.cshtml` عرض التفاصيل.
- `Views/Specialties/Delete.cshtml` تأكيد الحذف.
- `Views/Error/NotFoundPage.cshtml` صفحة الخطأ.

## قواعد مهمة عند إضافة View جديدة

### 1) اتبع اسم الـ Controller والـ Action

لو عندك `DoctorsController` وعمل `Index()`، يبقى الـ view غالبًا يكون:

```text
Views/Doctors/Index.cshtml
```

ولو الـ action اسمها `Create()`:

```text
Views/Doctors/Create.cshtml
```

### 2) استخدم نفس الـ layout

كل الصفحات لازم تفضل ماشية على `_Layout.cshtml` علشان الشكل يفضل موحد.

### 3) خليك على Bootstrap في الواجهة

المشروع مبني حاليًا على Bootstrap 5، فالأفضل عند إضافة Views جديدة تستخدم:

- `container`, `row`, `col-*`
- `card`, `table`, `form-control`, `btn`
- `badge`, `alert`, `list-group`

### 4) حافظ على RTL

الصفحة الأساسية مضبوطة على `dir="rtl"`، فكل تصميم جديد لازم يراعي الاتجاه العربي.

### 5) استخدم validation واضح

في صفحات الإضافة والتعديل:

- استخدم `required` للحقول الأساسية.
- استخدم `minlength` و`maxlength` عند الحاجة.
- استخدم `type="url"` أو `type="email"` لو الحقل مناسب.
- أضف `invalid-feedback` لرسائل الخطأ.

## طريقة الشغل على أي View جديدة

1. ابدأ بتحديد الـ Controller والـ Action.
2. أنشئ ملف الـ view داخل نفس اسم الفولدر.
3. اربطه بـ model واضح باستخدام `@model`.
4. استخدم Bootstrap cards أو tables بدل HTML عادي.
5. أضف empty state لو الصفحة ممكن ترجع بيانات فاضية.
6. تأكد إن الصفحة شغالة على الموبايل والديسكتوب.

## مثال بسيط لصفحة قائمة

```cshtml
@model List<SomeModel>

<div class="card surface-card">
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th class="text-end">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var item in Model)
                    {
                        <tr>
                            <td>@item.Name</td>
                            <td class="text-end">
                                <a class="btn btn-sm btn-outline-primary" href="#">Edit</a>
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    </div>
</div>
```

## مثال بسيط لصفحة فورم

```cshtml
<form method="post" class="row g-3 needs-validation" novalidate>
    <div class="col-md-6">
        <label class="form-label">Name</label>
        <input class="form-control" required minlength="2" />
        <div class="invalid-feedback">Name is required.</div>
    </div>
</form>
```

## ملاحظات مهمة للمستقبل

- المشروع قابل للتوسع، فالأفضل أي View جديدة تكون مبنية بنفس الشكل الحالي.
- لو هنضيف صفحات كثيرة بعدين، يفضل نمشي على نفس النمط: hero بسيط، card واضح، table منظمة، وفورمز فيها validation.
- لو الصفحة فيها بيانات كثيرة، استخدم `table-responsive` أو قسمها إلى cards.

## الملفات اللي ما ينفعش تتغير كثير

- `Views/Shared/_Layout.cshtml`
- `Views/Shared/_Navbar.cshtml`
- `Views/_ViewStart.cshtml`

## لو هتضيف صفحة جديدة

اتبع الترتيب ده:

1. أضف الـ action في الـ controller.
2. أنشئ ملف الـ view في الفولدر المناسب.
3. اربطه بالـ model.
4. خليه Bootstrap-friendly.
5. اختبره على شاشة صغيرة وكبيرة.

## Workflow سريع للمبتدئ

لو هتعدل View واحدة فقط:

1. افتح الـ controller وشوف اسم الـ action.
2. افتح ملف الـ view المقابل.
3. عدّل التصميم أو الفورم.
4. شغّل المشروع بـ `dotnet run`.
5. افتح الصفحة في المتصفح وتأكد من الشكل والـ validation.
6. لو ظهر خطأ، راجع الـ terminal والـ browser.

## ملخص سريع

- اعمل clone ثم افتح المشروع في VS Code الأزرق.
- ثبّت الإضافات الأساسية قبل الشغل.
- شغّل المشروع بـ `dotnet run`.
- اشتغل على ملفات الـ Views فقط لو المطلوب واجهة.
- حافظ على Bootstrap + RTL + validation.
- أي صفحة جديدة لازم تفضل متناسقة مع الموجود.
