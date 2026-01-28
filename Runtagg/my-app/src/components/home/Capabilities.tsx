import SectionWrapper from "./SectionWrapper";

const cards = [
  {
    title: "Game Development",
    description:
      "Indie prototyping, jam games and competition builds across PC, mobile and web.",
    icon: "🎮",
    tags: ["Unity", "Unreal", "Godot", "2D / 3D"],
  },
  {
    title: "Web & Platforms",
    description:
      "From SaaS dashboards to student products and PoC platforms with real users.",
    icon: "🖥",
    tags: ["Next.js", "Django", "FastAPI", "SaaS"],
  },
  {
    title: "AI & Competitions",
    description:
      "Teknofest, global hackathons and AI demos that push ideas into real prototypes.",
    icon: "🚀",
    tags: ["ML", "Hackathons", "Teknofest", "PoC"],
  },
];

export default function Capabilities() {
  return (
    <SectionWrapper id="capabilities" className="space-y-10">
      <div className="space-y-3">
        <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
          Capabilities
        </p>
        <h2 className="text-2xl font-semibold uppercase tracking-[0.18em] text-slate-100 sm:text-3xl">
          What we build
        </h2>
        <p className="max-w-2xl text-sm text-slate-300">
          We form small, focused crews around ideas — from indie games to
          scalable web platforms and competition prototypes.
        </p>
      </div>

      <div className="grid gap-6 md:grid-cols-3">
        {cards.map((card) => (
          <div
            key={card.title}
            className="group glass-panel-subtle relative flex flex-col gap-4 border border-white/10 p-5 transition duration-200 hover:-translate-y-1 hover:border-[#7C3AED]/80 hover:shadow-[0_22px_80px_rgba(15,23,42,0.95)]"
          >
            <div className="absolute inset-x-6 top-0 h-px bg-gradient-to-r from-transparent via-[#7C3AED]/60 to-transparent opacity-0 transition group-hover:opacity-100" />
            <div className="flex items-center gap-3">
              <div className="flex h-9 w-9 items-center justify-center rounded-2xl bg-slate-900/70 text-lg">
                <span>{card.icon}</span>
              </div>
              <h3 className="text-sm font-semibold uppercase tracking-[0.24em] text-slate-100">
                {card.title}
              </h3>
            </div>
            <p className="text-xs leading-relaxed text-slate-300/90">
              {card.description}
            </p>
            <div className="flex flex-wrap gap-2 pt-1">
              {card.tags.map((tag) => (
                <span
                  key={tag}
                  className="rounded-full border border-white/15 bg-slate-900/70 px-3 py-1 text-[10px] uppercase tracking-[0.22em] text-slate-300/90"
                >
                  {tag}
                </span>
              ))}
            </div>
          </div>
        ))}
      </div>
    </SectionWrapper>
  );
}

