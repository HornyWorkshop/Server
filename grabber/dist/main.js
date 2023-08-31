import { chromium } from "playwright";
(async () => {
    const browser = await chromium.launch({ devtools: true });
    const page = await browser.newPage();
    await page.goto("https://hidemy.name/ru/proxy-list/?maxtime=30&type=h#list", { waitUntil: "networkidle" });
})();
